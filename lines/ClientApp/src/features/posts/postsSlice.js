import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

const initialState = {
    posts: [],
    status: "idle",
    error: null
};

export const fetchPosts = createAsyncThunk(
    "posts/fetchPosts",
    async(data) => {
        let url = `/api/Posts`;

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
    async ({ userName, postId }) => {
        return axios
            .get(`/api/Posts/${postId}`)
            .then((response) => response.data);
    });

const postsSlice = createSlice({
    name: "posts",
    initialState,
    reducers: {
        // reducers
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
                state.posts = action.payload;
            })
            .addCase(fetchPost.rejected, (state, action) => {
                state.status = "failed";
                state.error = action.error.message;
            });
    }
});

export const { } = postsSlice.actions;

export default postsSlice.reducer;