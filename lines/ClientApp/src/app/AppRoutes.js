import Home from "../common/Home";
import NotificationsPage from "../features/notifications/NotificationsPage";
import PostPage from "../common/PostPage";
import ProfilePage from "../common/ProfilePage";
import SettingsPage from "../common/SettingsPage";
import SearchPage from "../common/SearchPage";
import Callback from "../common/Callback";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: "/profile/:userName/post/:postId",
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
        path: "/profile/:userName",
        element: <ProfilePage />
    },
    {
        path: "/search",
        element: <SearchPage />
    },
    {
        path: "/callback",
        element: <Callback />
    },
];

export default AppRoutes;
