import NavMenu from './NavMenu';
import { Columns } from "react-bulma-components";
import SearchMenu from './SearchMenu';

export default function Layout({ children }) {
    return (
        <Columns className="my-4">
            <Columns.Column size={3}>
                <NavMenu />
            </Columns.Column>
            
            <Columns.Column>
                {children}
            </Columns.Column>

            <Columns.Column size={3}>
                <SearchMenu />
            </Columns.Column>
        </Columns>
    );
}
