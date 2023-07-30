import NavMenu from './NavMenu';
import { Columns } from "react-bulma-components";

export default function Layout({ children }) {
    return (
        <Columns className="my-4">
            <Columns.Column>
                <NavMenu />
            </Columns.Column>
            
            <Columns.Column>
                {children}
            </Columns.Column>

            <Columns.Column>
                search and footer
            </Columns.Column>
        </Columns>
    );
}
