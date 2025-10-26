import type { LoggedUser } from "../../@types/user";
import NavBarItem from "./NavBarItemComponent";

interface NavBarProps {
  loggedUser: LoggedUser;
}

const NavBar: React.FC<NavBarProps> = ({ loggedUser }) => {
  const userIcon = (image: string) => (
    <>
      <span className="text-white">{image[0]}</span>
    </>
  );
  
  return (
    <div className="fixed flex w-[100px] p-5 h-full bg-transparent">
      <div className="bg-black w-full flex flex-col items-center p-3">
        <NavBarItem label="Usuário" icon={userIcon(loggedUser.icon)} />
      </div>
    </div>
  );
};

export default NavBar;