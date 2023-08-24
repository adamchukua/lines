import React from "react";
import User from "./User";

export default function UsersList({ users }) {
    return (
        <>
            {users?.map((user) => (
                <React.Fragment key={user.id}>
                    <User user={user} />
                </React.Fragment>
            ))}
        </>
    );
}
