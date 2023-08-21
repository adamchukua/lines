import { configureStore } from "@reduxjs/toolkit";
import postsSlice from "../features/posts/postsSlice";
import notificationsSlice from "../features/notifications/notificationsSlice";
import userSlice from "../features/user/userSlice";
import repliesSlice from "../features/replies/repliesSlice";
import likesSlice from "../features/likes/likesSlice";
import searchUsersSlice from "../features/user/search/searchUsersSlice";

export const store = configureStore({
    reducer: {
        posts: postsSlice,
        replies: repliesSlice,
        likes: likesSlice,
        notifications: notificationsSlice,
        user: userSlice,
        searchUser: searchUsersSlice
    }
});