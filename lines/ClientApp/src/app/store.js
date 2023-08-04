import { configureStore } from "@reduxjs/toolkit";
import postsSlice from "../features/posts/postsSlice";
import notificationsSlice from "../features/notifications/notificationsSlice";

export const store = configureStore({
    reducer: {
        posts: postsSlice,
        notifications: notificationsSlice
    }
});