import { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchPosts } from "../features/posts/postsSlice";
import InfiniteScroll from 'react-infinite-scroll-component';
import PostsList from "../features/posts/PostsList";
import DataDisplay from './DataDisplay';

export default function Home() {
    const dispatch = useDispatch();
    const posts = useSelector((state) => state.posts);
    const [page, setPage] = useState(1);
    const hasMore = posts.posts.length > 0;

    useEffect(() => {
        dispatch(fetchPosts({ pageNumber: page }));
    }, [dispatch, page]);

    const loadMore = () => {
        setPage(prevPage => prevPage + 1);
    };

    return (
        <DataDisplay status={posts.status} error={posts.error} isInfiniteScroll={true}>
            <InfiniteScroll
                dataLength={posts.posts.length}
                next={loadMore}
                hasMore={hasMore}
            >
                <PostsList posts={posts.posts} />
            </InfiniteScroll>
        </DataDisplay>
    );
}
