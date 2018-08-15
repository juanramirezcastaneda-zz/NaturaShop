class Application extends React.Component {
    render() {
        return (
            <div>
                <NavBar />
                <div>This is the application component</div>
            </div>
        );
    }
}

ReactDOM.render(
    <Application />,
    document.getElementById('body')
);


