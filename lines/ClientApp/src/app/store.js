import { configureStore } from "@reduxjs/toolkit";
import postsSlice from "../features/posts/postsSlice";
import notificationsSlice from "../features/notifications/notificationsSlice";
import userSlice from "../features/user/userSlice";
import repliesSlice from "../features/replies/repliesSlice";

export const store = configureStore({
    reducer: {
        posts: postsSlice,
        replies: repliesSlice,
        notifications: notificationsSlice,
        user: userSlice
    }
});