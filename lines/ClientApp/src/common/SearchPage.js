import { useEffect, useState } from 'react';
import { useSearchParams } from "react-router-dom";
import { useDispatch, useSelector } from 'react-redux';
import { searchPosts, clear } from "../features/posts/postsSlice";
import { searchUsers } from "../features/user/search/searchUsersSlice";
import InfiniteScroll from 'react-infinite-scroll-component';
import PostsList from "../features/posts/PostsList";
import DataDisplay from './DataDisplay';
import UsersList from './UsersList';

export default function SearchPage() {
    const [searchParams, setSearchParams] = useSearchParams();
    const query = searchParams.get("query");
    const dispatch = useDispatch();
    const posts = useSelector((state) => state.posts);
    const users = useSelector((state) => state.searchUser);
    const [postsPage, setPostsPage] = useState(1);
    const [usersPage, setUsersPage] = useState(1);
    const hasMorePosts = posts.posts.length > 0;
    const hasMoreUsers = users.users.length > 0;
    const [selectedTab, setSelectedTab] = useState("posts");

    useEffect(() => {
        switch (selectedTab) {
            case "posts":
                dispatch(clear());
                dispatch(searchPosts({ query: query, pageNumber: postsPage }));
                break;
            case "users":
                dispatch(searchUsers({ query: query, pageNumber: postsPage }));
                break;
        }
    }, [dispatch, selectedTab]);

    const loadMorePosts = () => {
        setPostsPage(prevPage => prevPage + 1);
    };

    const loadMoreUsers = () => {
        setUsersPage(prevPage => prevPage + 1);
    };

    return (
        <>
            <div className="tabs">
                <ul>
                    <li className={selectedTab === "posts" ? "is-active" : ""}>
                        <a onClick={() => setSelectedTab("posts")}>Posts</a>
                    </li>
                    <li className={selectedTab === "users" ? "is-active" : ""}>
                        <a onClick={() => setSelectedTab("users")}>Users</a>
                    </li>
                </ul>
            </div>

            <DataDisplay status={posts.status} error={posts.error} isInfiniteScroll={true}>
                {selectedTab === "posts" && (
                    <InfiniteScroll
                        dataLength={posts.posts.length}
                        next={loadMorePosts}
                        hasMore={hasMorePosts}
                    >
                        <PostsList posts={posts.posts} />
                    </InfiniteScroll>
                )}
            </DataDisplay>

            <DataDisplay status={users.status} error={users.error} isInfiniteScroll={true}>
                {selectedTab === "users" && (
                    <InfiniteScroll
                        dataLength={users.users.length}
                        next={loadMoreUsers}
                        hasMore={hasMoreUsers}
                    >
                        <UsersList users={users.users} />
                    </InfiniteScroll>
                )}
            </DataDisplay>
        </>
    );
}
