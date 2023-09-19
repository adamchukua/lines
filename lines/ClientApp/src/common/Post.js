import { useEffect, useState } from 'react';
import { CornerUpLeft, Repeat, Heart, Share } from 'react-feather';
import { useDispatch } from 'react-redux';
import { addLike, checkLike } from '../features/likes/likesSlice';

export default function Post({ isThread, isMainPost, post }) {
    const getHumanReadableTime = (datetime) => {
        const now = new Date();
        const timeDifference = now - datetime;

        const minute = 60 * 1000;
        const hour = 60 * minute;
        const day = 24 * hour;
        const week = 7 * day;
        const month = 30 * day;
        const year = 365 * day;

        if (timeDifference < minute) {
            return `${Math.floor(timeDifference / 1000)}s`;
        } else if (timeDifference < hour) {
            return `${Math.floor(timeDifference / minute)}m`;
        } else if (timeDifference < day) {
            return `${Math.floor(timeDifference / hour)}h`;
        } else if (timeDifference < week) {
            return `${Math.floor(timeDifference / day)}d`;
        } else if (timeDifference < month) {
            return `${Math.floor(timeDifference / week)}w`;
        } else if (timeDifference < year) {
            return `${Math.floor(timeDifference / month)}mo`;
        } else {
            return `${Math.floor(timeDifference / year)}y`;
        }
    };

    const dispatch = useDispatch();
    const [isLiked, setIsLiked] = useState(false);
    const [isNewLike, setIsNewLike] = useState(false);

    useEffect(() => {
        dispatch(checkLike({ postId: post.id })).then(result => {
            if (result.payload.data) {
                setIsLiked(true);
            }
        });
    }, [post]);

    const handleLike = async () => {
        const result = await dispatch(addLike({ postId: post.id }));

        if (result.payload.data) {
            setIsLiked(true);
            setIsNewLike(true);
        }
    };

    return (
        <>
            {post && (
                <article className="media" style={isMainPost ? { fontSize: "1.2rem" } : {}}>
                    <div className="media-left">
                        <figure className="image is-64x64">
                            <a href={`profile/${post.user?.userName}`}>
                                <img src={`/images/avatars/${post.user?.avatar}`} className="is-rounded" alt="Image" />
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

                                    <p className="ml-2">{post?.likesCount + isNewLike}</p>
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
