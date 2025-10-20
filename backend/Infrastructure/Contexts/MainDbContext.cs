using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RpgApi.Domain.Entities;

namespace RpgApi.Infrastructure.Contexts;

public class MainDbContext(DbContextOptions<MainDbContext> options) 
    : IdentityDbContext<User, IdentityRole<int>, int>(options)
{
    public DbSet<GameSystem> GameSystems { get; set; }
    public DbSet<SheetModel> SheetModels { get; set; }
    public DbSet<CharacterSheet> CharacterSheets { get; set; }
    public DbSet<GameSession> GameSessions { get; set; }
    public DbSet<SessionPlayer> SessionPlayers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<GameSystem>(gameSystem =>
        {
            gameSystem.HasIndex(gs => gs.Name)
                .IsUnique();

            gameSystem.Property(gs => gs.Name)
                .HasMaxLength(100);
        });
        
        modelBuilder.Entity<CharacterSheet>(characterSheet =>
        {
            characterSheet.Property(cs => cs.Name)
                .HasMaxLength(150);
        });

        modelBuilder.Entity<SheetModel>(sheetModel =>
        {
            sheetModel.Property(sm => sm.Name)
                .HasMaxLength(100);
        });

        modelBuilder.Entity<SessionPlayer>(sessionPlayer =>
        {
            sessionPlayer.HasKey(sp => new { sp.SessionId, sp.PlayerId });
            
            sessionPlayer.HasOne(sp => sp.Player)
                .WithMany(u => u.SessionsLink)
                .HasForeignKey(sp => sp.PlayerId);
            
            sessionPlayer.HasOne(sp => sp.Session)
                .WithMany(gs => gs.PlayersLink)
                .HasForeignKey(sp => sp.SessionId);
        });

        modelBuilder.Entity<GameSession>(gameSession =>
        {
            gameSession.HasMany(gs => gs.SessionSheets)
                .WithOne(cs => cs.GameSession)
                .HasForeignKey(cs => cs.GameSessionId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            gameSession.Property(gs => gs.Name)
                .HasMaxLength(100);
        });
            
        
        modelBuilder.Entity<User>()
            .HasMany(u => u.GmedSessions)
            .WithOne(gs => gs.GameMaster)
            .HasForeignKey(gs => gs.GameMasterId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}