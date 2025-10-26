interface NavBarItemProps {
  icon?: React.ReactNode;
  label?: string;
}

const NavBarItem: React.FC<NavBarItemProps> = ({ icon, label }) => {
  return (
    <div className="relative flex w-[25px] h-[25px]">
      {icon}
      {label &&
        <div className="absolute">
          {label}
        </div>
      }
    </div>
  );
}

export default NavBarItem;