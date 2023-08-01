import Home from "./components/Home";
import PostPage from "./components/PostPage";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: "/post",
        element: <PostPage />
    }
];

export default AppRoutes;
