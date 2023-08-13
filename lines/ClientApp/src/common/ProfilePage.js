import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';
import { fetchUser } from "../features/user/userSlice";
import PostsList from "../features/posts/PostsList";
import UserInfo from "../features/user/UserInfo";
import DataDisplay from "../common/DataDisplay";

export default function ProfilePage() {
    const userName = useParams()["userName"];
    const dispatch = useDispatch();
    const user = useSelector((state) => state.user);
    const [selectedTab, setSelectedTab] = useState("posts");

    useEffect(() => {
        dispatch(fetchUser(userName));
    }, [dispatch]);

    return (
        <DataDisplay status={user.status} error={user.error}>
            <UserInfo user={user.user} />

            <div className="tabs mb-0 mt-2 mb-4">
                <ul>
                    <li className={selectedTab === "posts" ? "is-active" : ""}>
                        <a onClick={() => setSelectedTab("posts")}>Posts</a>
                    </li>

                    <li className={selectedTab === "replies" ? "is-active" : ""}>
                        <a onClick={() => setSelectedTab("replies")}>Replies</a>
                    </li>

                    <li className={selectedTab === "likes" ? "is-active" : ""}>
                        <a onClick={() => setSelectedTab("likes")}>Likes</a>
                    </li>
                </ul>
            </div>

            {selectedTab === "posts" && (
                <PostsList posts={user.user.posts?.filter(p => p.repliedPostId === null)} />
            )}

            {selectedTab === "replies" && (
                <PostsList posts={user.user.posts?.filter(p => p.repliedPostId !== null)} />
            )}

            {selectedTab === "likes" && (
                <PostsList posts={user.user.likes} />
            )}
        </DataDisplay>
    );
}
