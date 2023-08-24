import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

const initialState = {
    users: [],
    status: "idle",
    error: null
};

export const searchUsers = createAsyncThunk(
    "searchUsers/searchUsers",
    async (data) => {
        let url = `/api/Users/Search/${data?.query}`;

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

const searchUsersSlice = createSlice({
    name: "searchUsers",
    initialState,
    reducers: {
        clear: (state) => {
            state.users = [];
        }
    },
    extraReducers(builder) {
        builder
            .addCase(searchUsers.pending, (state, action) => {
                state.status = "loading";
            })
            .addCase(searchUsers.fulfilled, (state, action) => {
                state.status = "succeeded";
                state.users = action.payload;
            })
            .addCase(searchUsers.rejected, (state, action) => {
                state.status = "failed";
                state.error = action.error.message;
            });
    }
});

export const { clear } = searchUsersSlice.actions;

export default searchUsersSlice.reducer;