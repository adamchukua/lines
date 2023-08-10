import Home from "../common/Home";
import NotificationsPage from "../features/notifications/NotificationsPage";
import PostPage from "../common/PostPage";
import ProfilePage from "../common/ProfilePage";
import SettingsPage from "../common/SettingsPage";

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
