import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';
import { fetchUser } from "../features/user/userSlice";
import { fetchUserReplies } from "../features/replies/repliesSlice";
import { fetchUserLikes } from "../features/likes/likesSlice";
import PostsList from "../features/posts/PostsList";
import UserInfo from "../features/user/UserInfo";
import DataDisplay from "../common/DataDisplay";

export default function ProfilePage() {
    const userName = useParams()["userName"];
    const dispatch = useDispatch();
    const user = useSelector((state) => state.user);
    const replies = useSelector((state) => state.replies);
    const likes = useSelector((state) => state.likes);
    const [selectedTab, setSelectedTab] = useState("posts");

    useEffect(() => {
        dispatch(fetchUser(userName));
    }, [dispatch]);

    useEffect(() => {
        dispatch(fetchUserReplies(user.user?.userName));
        dispatch(fetchUserLikes(user.user?.userName));
    }, [user.user.userName]);

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

            <DataDisplay status={replies.status} error={replies.error}>
                {selectedTab === "replies" && (
                    <PostsList posts={replies.replies} />
                )}
            </DataDisplay>

            <DataDisplay status={likes.status} error={likes.error}>
                {selectedTab === "likes" && (
                    <PostsList posts={likes.likes} />
                )}
            </DataDisplay>
        </DataDisplay>
    );
}
