import Post from "./Post"

export default function Thread({ isFullThread, hasMainPost, posts }) {
    return (
        <>
            {posts && posts.map((post, index) => (
                <Post
                    isThread={posts.length - 1 !== index ? true : isFullThread}
                    post={post}
                    key={index}
                    isMainPost={hasMainPost && index === posts.length - 1} />
            ))}
        </>
    );
}
    