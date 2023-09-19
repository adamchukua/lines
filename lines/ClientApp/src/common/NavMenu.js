import NewPostModal from "./NewPostModal";
import userManager from '../app/oidc-config';
import { useEffect, useState } from "react";

export default function NavMenu() {
    const [user, setUser] = useState({});

    useEffect(() => {
        userManager.getUser().then((user) => {
            if (user) {
                setUser(user);
            }
        });
    }, []);

    const handleLogin = () => {
        userManager.signinRedirect();
    };

    const handleLogout = () => {
        userManager.signoutRedirect();
    };

    return (
        <>
            <nav className="pos-fix">
                <a href="/">
                    <img src="images/logo_big.svg" className="logo" alt="lines" />
                </a>

                {!user?.profile ? (
                    <div className="is-flex is-flex-direction-column mt-5">
                        To use lines fully pleas log in.

                        <button className="btn mt-4" onClick={handleLogin}>Login</button>
                    </div>
                ) : (
                    <nav className="pos-fix">
                        <ul className="menu-list my-4">
                            <li><a href="/">Home</a></li>
                            <li><a href="/profile">Profile</a></li>
                            <li><a href="/notifications">Notifications</a></li>
                            <li><a href="/settings">Settings</a></li>

                            <button className="btn mt-4" onClick={handleLogout}>Logout</button>
                        </ul>

                        <NewPostModal />
                    </nav>
                )}
            </nav>
        </>
    );
}
