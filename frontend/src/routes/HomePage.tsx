import type { LoggedUser } from "../@types/user";
import NavBar from "../components/NavBar/NavBarComponent";

const HomePage = () => {
    const user: LoggedUser = {
        username: "ViniciusLibano",
        fullname: "Vinicius Libano",
        icon: ""
    }

    return (
        <div className="">
            <NavBar loggedUser={user} />
        </div>
    );
};

export default HomePage;