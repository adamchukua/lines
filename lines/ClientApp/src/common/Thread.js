import Post from "./Post"

export default function Thread({ isFullThread, posts }) {
    return (
        <>
            {posts && posts.map((post, index) => (
                <Post isThread={posts.length - 1 != index ? true : isFullThread} post={post} />
            ))}
        </>
    );
}
