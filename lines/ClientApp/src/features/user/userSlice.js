import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

const initialState = {
    user: {},
    status: "idle",
    error: null
};

export const fetchUser = createAsyncThunk(
    "user/fetchUser",
    async (userName) => {
        return axios
            .get(`https://localhost:7122/api/Users/${userName}`)
            .then((response) => response.data);
    });

const userSlice = createSlice({
    name: "user",
    initialState,
    reducers: {
        // reducers
    },
    extraReducers(builder) {
        builder
            .addCase(fetchUser.pending, (state, action) => {
                state.status = "loading";
            })
            .addCase(fetchUser.fulfilled, (state, action) => {
                state.status = "succeeded";
                state.user = action.payload;
            })
            .addCase(fetchUser.rejected, (state, action) => {
                state.status = "failed";
                state.error = action.error.message;
            });
    }
});

export const { } = userSlice.actions;

export default userSlice.reducer;