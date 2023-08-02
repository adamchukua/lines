import Home from "./components/Home";
import NotificationsPage from "./components/NotificationsPage";
import PostPage from "./components/PostPage";
import ProfilePage from "./components/ProfilePage";
import SettingsPage from "./components/SettingsPage";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: "/post",
        element: <PostPage />
    },
    {
        path: "/notifications",
        element: <NotificationsPage />
    },
    {
        path: "/settings",
        element: <SettingsPage />
    },
    {
        path: "/profile",
        element: <ProfilePage />
    }
];

export default AppRoutes;
