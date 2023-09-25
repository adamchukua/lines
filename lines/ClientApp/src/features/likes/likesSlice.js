import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";
import userManager from "../../app/oidc-config";

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

export const addLike = createAsyncThunk(
    "likes/addLike",
    async (data) => {
        const user = await userManager.getUser();
        data.userId = user.profile.sub;

        return axios
            .post(`https://localhost:7122/api/Likes/`, data, {
                headers: {
                    'Authorization': `Bearer ${user.access_token}`
                }
            });
    });

export const deleteLike = createAsyncThunk(
    "likes/deleteLike",
    async (data) => {
        const user = await userManager.getUser();
        data.userId = user.profile.sub;

        return axios
            .delete(`https://localhost:7122/api/Likes/`, {
                headers: {
                    'Authorization': `Bearer ${user.access_token}`
                },
                data
            });
    });

export const checkLike = createAsyncThunk(
    "likes/addLike",
    async (data) => {
        const user = await userManager.getUser();
        const userId = user.profile.sub;

        return axios
            .get(`https://localhost:7122/api/Likes/${data?.postId}/${userId}`);
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