import React from "react";
import Post from "../../common/Post";
import Thread from "../../common/Thread";

export default function PostsList({ posts }) {
    const findOriginalPost = (reply) => {
        return posts.find(p => p.id === reply.repliedPostId);
    }

    return (
        <>
            {posts?.map((post) => (
                <React.Fragment key={post.id}>
                    {findOriginalPost(post) ? (
                        <Thread posts={[findOriginalPost(post), post]} />
                    ) : (
                        <Post post={post} />
                    )}
                </React.Fragment>
            ))}
        </>
    );
}
