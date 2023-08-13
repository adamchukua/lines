import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchPosts } from "../features/posts/postsSlice"
import PostsList from "../features/posts/PostsList";
import DataDisplay from './DataDisplay';

export default function Home() {
    const dispatch = useDispatch();
    const posts = useSelector((state) => state.posts);

    useEffect(() => {
        dispatch(fetchPosts());
    }, [dispatch]);

    return (
        <DataDisplay status={posts.status} error={posts.error}>
            <PostsList posts={posts.posts} />
        </DataDisplay>
    );
}
