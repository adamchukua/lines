import React from "react";
import User from "./User";

export default function UsersList({ users }) {
    return (
        <>
            {users?.map((user, index) => (
                <React.Fragment key={index}>
                    <User user={user} />
                </React.Fragment>
            ))}
        </>
    );
}
