import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

const initialState = {
    notifications: [],
    status: "idle",
    error: null
};

export const fetchNotifications = createAsyncThunk(
    "notifications/fetchNotifications",
    async () => {
        return axios
            .get("/api/Notifications/")
            .then((response) => response.data);
    });

const notificationsSlice = createSlice({
    name: "notifications",
    initialState,
    reducers: {
        // reducers
    },
    extraReducers(builder) {
        builder
            .addCase(fetchNotifications.pending, (state, action) => {
                state.status = "loading";
            })
            .addCase(fetchNotifications.fulfilled, (state, action) => {
                state.status = "succeeded";
                state.notifications = action.payload;
            })
            .addCase(fetchNotifications.rejected, (state, action) => {
                state.status = "failed";
                state.error = action.error.message;
            });
    }
});

export const { } = notificationsSlice.actions;

export default notificationsSlice.reducer;