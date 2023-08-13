import { configureStore } from "@reduxjs/toolkit";
import postsSlice from "../features/posts/postsSlice";
import notificationsSlice from "../features/notifications/notificationsSlice";
import userSlice from "../features/user/userSlice";

export const store = configureStore({
    reducer: {
        posts: postsSlice,
        notifications: notificationsSlice,
        user: userSlice
    }
});