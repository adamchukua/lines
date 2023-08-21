import { useEffect, useState } from "react";
import { Form } from "react-bulma-components";
import { useDispatch, useSelector } from 'react-redux';
import { searchUsers, clear } from "../features/user/search/searchUsersSlice";
import SearchMenuList from "./SearchMenuList";

export default function SearchMenu() {
    const dispatch = useDispatch();
    const users = useSelector((state) => state.searchUser);
    const [query, setQuery] = useState("");
    const year = new Date().getFullYear();

    useEffect(() => {
        if (query) {
            dispatch(searchUsers(query));
        } else {
            dispatch(clear());
        }
    }, [dispatch, query]);

    return (
        <section className="pos-fix">
            <div className="search">
                <Form.Input
                    placeholder="Search"
                    rounded={true}
                    className="has-text-centered"
                    style={{ width: "278px" }}
                    onChange={(e) => setQuery(e.target.value)}
                />

                <SearchMenuList users={users?.users} />
            </div>

            <p className="has-text-centered mt-5">&copy; {year} lines production</p>
        </section>
    );
}
