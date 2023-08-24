import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Form } from "react-bulma-components";
import { useDispatch, useSelector } from 'react-redux';
import { searchUsers, clear } from "../features/user/search/searchUsersSlice";
import SearchMenuList from "./SearchMenuList";

export default function SearchMenu() {
    const navigate = useNavigate();
    const dispatch = useDispatch();
    const users = useSelector((state) => state.searchUser);
    const [query, setQuery] = useState("");
    const year = new Date().getFullYear();

    useEffect(() => {
        if (query) {
            dispatch(searchUsers({ query: query }));
        } else {
            dispatch(clear());
        }
    }, [dispatch, query]);

    const handleKeyDown = (event) => {
        if (event.key === 'Enter') {
            navigate(`/search?query=${query}`);
        }
    }

    return (
        <section className="pos-fix">
            <div className="search">
                <Form.Input
                    placeholder="Search"
                    rounded={true}
                    className="has-text-centered"
                    style={{ width: "278px" }}
                    onChange={(e) => setQuery(e.target.value)}
                    onKeyDown={handleKeyDown}
                />

                <SearchMenuList users={users?.users} />
            </div>

            <p className="has-text-centered mt-5">&copy; {year} lines production</p>
        </section>
    );
}
