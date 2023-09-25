import React from "react";
import Post from "../../common/Post";
import Thread from "../../common/Thread";

export default function PostsList({ posts }) {
    return (
        <>
            {posts?.map((post) => (
                <React.Fragment key={post.id}>
                    {post.parentPost ? (
                        <Thread posts={[post.parentPost, post]} />
                    ) : (
                        <Post post={post} />
                    )}
                </React.Fragment>
            ))}
        </>
    );
}
