class Application extends React.Component {
    render() {
        return (
            <div>
                <NavBar />
                <div className={"container body-content"}>
                    <div>This is the application component</div>
                    <Footer name="NaturaShop" />
                </div>
            </div>
        );
    }
}

ReactDOM.render(
    <Application />,
    document.getElementById('body')
);


