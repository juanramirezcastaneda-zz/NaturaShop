class NavBar extends React.Component {
    constructor(props) {
        super(props);
        this.state = { openClass: false };
    }

    handleClick = () => {
        this.setState((prevState) => ({
            openClass: !prevState.openClass ? 'nt-open-menu' : ''
        }));
    }

    render() {
        return (
            <nav className={"nt-navbar inverse"}>
                <div className={`nt-navbar-container ${this.state.openClass}`}>
                    <a className={"nt-navbar-brand"} href="">NaturaShop</a>
                    <a className={"nt-navbar-nav"} href="">Home</a>
                    <a className={"nt-navbar-nav"} href="">Customers</a>
                    <a className={"nt-navbar-nav"} href="">Employee</a>
                    <a className={"nt-navbar-nav"} href="">Products</a>
                    <a className={"nt-navbar-nav"} href="">Sales</a>
                    <div className={"nt-navbar-toggle"}>
                        <button type="button" onClick={this.handleClick}>
                            <span className={"sr-only"}>Toggle navigation</span>
                            <i className={"fa fa-bars fa-2x"}></i>
                        </button>
                    </div>
                </div>
            </nav>
        );
    }
}