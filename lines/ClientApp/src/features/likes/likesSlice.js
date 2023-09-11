import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

const initialState = {
    likes: [],
    status: "idle",
    error: null
};

export const fetchUserLikes = createAsyncThunk(
    "likes/fetchUserLikes",
    async (userName) => {
        return axios
            .get(`https://localhost:7122/api/Likes/${userName}`)
            .then((response) => response.data);
    });

const likesSlice = createSlice({
    name: "likes",
    initialState,
    reducers: {
        // reducers
    },
    extraReducers(builder) {
        builder
            // fetchUserLikes
            .addCase(fetchUserLikes.pending, (state, action) => {
                state.status = "loading";
            })
            .addCase(fetchUserLikes.fulfilled, (state, action) => {
                state.status = "succeeded";
                state.likes = action.payload;
            })
            .addCase(fetchUserLikes.rejected, (state, action) => {
                state.status = "failed";
                state.error = action.error.message;
            });
    }
});

export const { } = likesSlice.actions;

export default likesSlice.reducer;