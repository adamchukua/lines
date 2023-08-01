import Home from "./components/Home";
import NotificationsPage from "./components/NotificationsPage";
import PostPage from "./components/PostPage";

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
    }
];

export default AppRoutes;
