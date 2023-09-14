import { useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';
import { fetchPost } from "../features/posts/postsSlice";
import { fetchPostReplies } from "../features/posts/postsSlice";
import PostsList from "../features/posts/PostsList";
import ReplyInput from "./ReplyInput";
import DataDisplay from './DataDisplay';
import Thread from './Thread';

export default function PostPage() {
    const userName = useParams()["userName"];
    const postId = useParams()["postId"];
    const dispatch = useDispatch();
    const post = useSelector((state) => state.posts);
    const replies = useSelector((state) => state.posts);

    useEffect(() => {
        dispatch(fetchPost({ userName: userName, postId: postId }));
    }, [dispatch]);

    useEffect(() => {
        dispatch(fetchPostReplies(post.posts?.id));
    }, [post.posts.id]);

    return (
        <DataDisplay status={post.status} error={post.error}>
            <Thread posts={[post.posts.parentPost, post.posts]} hasMainPost={true} />

            <ReplyInput postId={post.posts.id} />

            <DataDisplay status={replies.status} error={replies.error}>
                <PostsList posts={replies.replies} />
            </DataDisplay>
        </DataDisplay>
    );
}
