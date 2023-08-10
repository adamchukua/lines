import NewPostModal from "./NewPostModal";

export default function NavMenu() {
    return (
        <>
            <nav>
                <img src="images/logo_big.svg" className="logo" alt="lines" />

                <ul className="menu-list my-4">
                    <li><a href="/">Home</a></li>
                    <li><a href="/profile">Profile</a></li>
                    <li><a href="/notifications">Notifications</a></li>
                    <li><a href="/settings">Settings</a></li>
                </ul>

                <NewPostModal />
            </nav>
        </>
    );
}
