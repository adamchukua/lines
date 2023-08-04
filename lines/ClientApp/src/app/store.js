import { configureStore } from "@redux/toolkit";
import postsSlice from "../features/posts/postsSlice";

export const store = configureStore({
    reducer: {
        posts: postsSlice
    }
});