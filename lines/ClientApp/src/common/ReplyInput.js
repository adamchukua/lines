import { useDispatch } from 'react-redux';
import { useState } from 'react';
import { addPost } from '../features/posts/postsSlice';

export default function ReplyInput({ postId }) {
    const dispatch = useDispatch();
    const [replyText, setReplyText] = useState('');

    const handleEnterPress = (e) => {
        if (e.key === 'Enter' && replyText.trim() !== '') {
            dispatch(addPost({ repliedPostId: postId, text: replyText }));
            setReplyText('');
        }
    };

    return (
        <>
            <input
                placeholder="Type your reply"
                className="reply my-5"
                value={replyText}
                onChange={(e) => setReplyText(e.target.value)}
                onKeyPress={handleEnterPress}
            />
        </>
    );
}
