import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

const initialState = {
    posts: [],
    status: "idle",
    error: null
};

export const fetchPosts = createAsyncThunk(
    "posts/fetchPosts",
    async () => {
        return axios
            .get("/api/Posts/")
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
            .addCase(fetchPosts.pending, (state, action) => {
                state.status = "loading";
            })
            .addCase(fetchPosts.fulfilled, (state, action) => {
                state.status = "succeeded";
                state.posts = action.payload;
            })
            .addCase(fetchPosts.rejected, (state, action) => {
                state.status = "failed";
                state.error = action.error.message;
            });
    }
});

export const { } = postsSlice.actions;

export default postsSlice.reducer;