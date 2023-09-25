import React from "react";
import SearchMenuItem from "./SearchMenuItem";

export default function SearchMenuList({ users }) {
    return (
        <div className="mt-4">
            {users?.map((user, key) => (
                <React.Fragment key={key}>
                    <SearchMenuItem user={user} />
                </React.Fragment>
            ))}
        </div>
    );
}
