import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";
import userManager from "../../app/oidc-config";

const initialState = {
    posts: [],
    status: "idle",
    error: null
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
        let url = `https://localhost:7122/api/Posts/Search/${data?.query}`;

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
            })
            .then((response) => {
                // Handle successful POST response here
                console.log('Post created successfully:', response.data);
            })
            .catch((error) => {
                // Handle error here
                console.error('Error creating post:', error);
            });
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
                state.posts = action.payload;
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
            });
    }
});

export const { clear } = postsSlice.actions;

export default postsSlice.reducer;