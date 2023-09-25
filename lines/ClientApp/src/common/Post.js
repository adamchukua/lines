import { useEffect, useState } from 'react';
import { CornerUpLeft, Repeat, Heart, Share } from 'react-feather';
import { useDispatch } from 'react-redux';
import { addLike, deleteLike, checkLike } from '../features/likes/likesSlice';
import { getHumanReadableTime } from '../features/posts/postsSlice';

export default function Post({ isThread, isMainPost, post }) {
    const dispatch = useDispatch();
    const [avatar, setAvatar] = useState("");
    const [isLiked, setIsLiked] = useState(false);
    const [isNewLike, setIsNewLike] = useState(false);
    const [likeStatus, setLikeStatus] = useState(0);

    useEffect(() => {
        dispatch(checkLike({ postId: post.id })).then(result => {
            if (result.payload.data) {
                setIsLiked(true);
            }
        });

        if (post) {
            if (post.user?.avatar) {
                setAvatar(`/images/avatars/${post.user?.avatar}`);
            } else {
                setAvatar(`https://ui-avatars.com/api/?name=${post.user?.name}`);
            }
        }
    }, [post]);

    const handleLike = async () => {
        if (isLiked) {
            const unlike = await dispatch(deleteLike({ postId: post.id }));

            if (unlike.payload.data) {
                setIsLiked(false);
                setIsNewLike(false);
                setLikeStatus(isNewLike ? 0 : -1);
                return;
            }
        }

        const like = await dispatch(addLike({ postId: post.id }));

        if (like.payload.data) {
            setIsLiked(true);
            setIsNewLike(true);
            setLikeStatus(1);
        }
    };

    return (
        <>
            {post && (
                <article className="media" style={isMainPost ? { fontSize: "1.2rem" } : {}}>
                    <div className="media-left">
                        <figure className="image is-64x64">
                            <a href={`profile/${post.user?.userName}`}>
                                <img src={avatar} className="is-rounded" alt="Image" />
                            </a>

                            {isThread && (<div className="thread-line"></div>)}
                        </figure>
                    </div>
                    <div className="media-content">
                        <div className="content">
                            <div className="is-flex is-justify-content-space-between">
                                <a href={`profile/${post.user?.userName}`}>
                                    <strong>{post?.user?.name}</strong> <small>@{post.user?.userName}</small>
                                </a>

                                <p>
                                    <small>{getHumanReadableTime(new Date(post?.createdAt))}</small>
                                </p>
                            </div>

                            <a href={`profile/${post.user?.userName}/post/${post?.id}`}>
                                {post?.text}
                            </a>
                        </div>

                        <nav className="level is-mobile mt-5">
                            <div className="level-left">
                                <a className="level-item text-black">
                                    <CornerUpLeft size={20} />

                                    <p className="ml-2">{post?.repliesCount}</p>
                                </a>

                                <a className="level-item text-black">
                                    <Repeat size={20} />

                                    <p className="ml-2">{post?.repostsCount}</p>
                                </a>

                                <a className="level-item text-black">
                                    <Heart size={20} className={isLiked ? "filledSvg" : ""} onClick={handleLike} />

                                    <p className="ml-2">{post?.likesCount + likeStatus}</p>
                                </a>

                                <a className="level-item text-black">
                                    <Share size={20} />

                                    <p className="ml-2">0</p>
                                </a>
                            </div>
                        </nav>
                    </div>
                </article>
            )}
        </>
    );
}
