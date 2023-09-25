import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";
import userManager from "../../app/oidc-config";

const initialState = {
    post: [],
    posts: [],
    replies: [],
    status: "idle",
    error: null,
};

export const getHumanReadableTime = (datetime) => {
    const now = new Date();
    const timeDifference = now - datetime;

    const minute = 60 * 1000;
    const hour = 60 * minute;
    const day = 24 * hour;
    const week = 7 * day;
    const month = 30 * day;
    const year = 365 * day;

    if (timeDifference < minute) {
        return `${Math.floor(timeDifference / 1000)}s`;
    } else if (timeDifference < hour) {
        return `${Math.floor(timeDifference / minute)}m`;
    } else if (timeDifference < day) {
        return `${Math.floor(timeDifference / hour)}h`;
    } else if (timeDifference < week) {
        return `${Math.floor(timeDifference / day)}d`;
    } else if (timeDifference < month) {
        return `${Math.floor(timeDifference / week)}w`;
    } else if (timeDifference < year) {
        return `${Math.floor(timeDifference / month)}mo`;
    } else {
        return `${Math.floor(timeDifference / year)}y`;
    }
};

export const fetchPosts = createAsyncThunk(
    "posts/fetchPosts",
    async (data) => {
        let url = `https://localhost:7122/api/Posts`;

        if (data?.pageNumber) {
            url += `?pageNumber=${data?.pageNumber}`;

            if (data?.pageSize) {
                url += `&pageSize=${data?.pageSize}`;
            }
        }

        return axios
            .get(url)
            .then((response) => response.data);
    });

export const fetchPost = createAsyncThunk(
    "posts/fetchPost",
    async ({ postId }) => {
        return axios
            .get(`https://localhost:7122/api/Posts/${postId}`)
            .then((response) => response.data);
    });

export const searchPosts = createAsyncThunk(
    "posts/searchPosts",
    async (data) => {
        let url = `https://localhost:7122/api/Posts/${data?.query}`;

        if (data?.pageNumber) {
            url += `?pageNumber=${data?.pageNumber}`;

            if (data?.pageSize) {
                url += `&pageSize=${data?.pageSize}`;
            }
        }

        return axios
            .get(url)
            .then((response) => response.data);
    });

export const addPost = createAsyncThunk(
    "posts/addPost",
    async (data) => {
        const user = await userManager.getUser();
        data.userId = user.profile.sub;

        return axios
            .post(`https://localhost:7122/api/Posts/`, data, {
                headers: {
                    'Authorization': `Bearer ${user.access_token}`
                }
            });
    });

export const fetchUserReplies = createAsyncThunk(
    "posts/fetchUserReplies",
    async (userName) => {
        return axios
            .get(`https://localhost:7122/api/Posts/${userName}/replies`)
            .then((response) => response.data);
    });

export const fetchPostReplies = createAsyncThunk(
    "posts/fetchPostReplies",
    async (postId) => {
        return axios
            .get(`https://localhost:7122/api/Posts/${postId}/replies`)
            .then((response) => response.data);
    });

const postsSlice = createSlice({
    name: "posts",
    initialState,
    reducers: {
        clear: (state) => {
            state.posts = [];
        }
    },
    extraReducers(builder) {
        builder
            // fetchPosts
            .addCase(fetchPosts.pending, (state, action) => {
                state.status = "loading";
            })
            .addCase(fetchPosts.fulfilled, (state, action) => {
                state.status = "succeeded";
                state.posts.push(...action.payload);
            })
            .addCase(fetchPosts.rejected, (state, action) => {
                state.status = "failed";
                state.error = action.error.message;
            })
            // fetchPost
            .addCase(fetchPost.pending, (state, action) => {
                state.status = "loading";
            })
            .addCase(fetchPost.fulfilled, (state, action) => {
                state.status = "succeeded";
                state.post = action.payload;
            })
            .addCase(fetchPost.rejected, (state, action) => {
                state.status = "failed";
                state.error = action.error.message;
            })
            // searchPosts
            .addCase(searchPosts.pending, (state, action) => {
                state.status = "loading";
            })
            .addCase(searchPosts.fulfilled, (state, action) => {
                state.status = "succeeded";
                state.posts = action.payload;
            })
            .addCase(searchPosts.rejected, (state, action) => {
                state.status = "failed";
                state.error = action.error.message;
            })
            // addPost
            .addCase(addPost.pending, (state, action) => {
                state.status = "loading";
            })
            .addCase(addPost.fulfilled, (state, action) => {
                state.status = "succeeded";
                state.replies.unshift(action.payload.data);
                console.log(action.payload);
            })
            .addCase(addPost.rejected, (state, action) => {
                state.status = "failed";
                state.error = action.error.message;
            })
            // fetchUserReplies
            .addCase(fetchUserReplies.pending, (state, action) => {
                state.status = "loading";
            })
            .addCase(fetchUserReplies.fulfilled, (state, action) => {
                state.status = "succeeded";
                state.replies = action.payload;
            })
            .addCase(fetchUserReplies.rejected, (state, action) => {
                state.status = "failed";
                state.error = action.error.message;
            })
            // fetchPostReplies
            .addCase(fetchPostReplies.pending, (state, action) => {
                state.status = "loading";
            })
            .addCase(fetchPostReplies.fulfilled, (state, action) => {
                state.status = "succeeded";
                state.replies = action.payload;
            })
            .addCase(fetchPostReplies.rejected, (state, action) => {
                state.status = "failed";
                state.error = action.error.message;
            })
    }
});

export const { clear } = postsSlice.actions;

export default postsSlice.reducer;