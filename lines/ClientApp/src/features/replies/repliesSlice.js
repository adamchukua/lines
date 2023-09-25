import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

const initialState = {
    replies: [],
    status: "idle",
    error: null
};

export const fetchUserReplies = createAsyncThunk(
    "replies/fetchUserReplies",
    async (userName) => {
        return axios
            .get(`https://localhost:7122/api/Posts/GetUserReplies/${userName}`)
            .then((response) => response.data);
    });

export const fetchPostReplies = createAsyncThunk(
    "replies/fetchPostReplies",
    async (postId) => {
        return axios
            .get(`https://localhost:7122/api/Posts/GetPostReplies/${postId}`)
            .then((response) => response.data);
    });

const repliesSlice = createSlice({
    name: "replies",
    initialState,
    reducers: {
        // reducers
    },
    extraReducers(builder) {
        builder
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
            });
    }
});

export const { } = repliesSlice.actions;

export default repliesSlice.reducer;