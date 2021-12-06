import React, { Component } from 'react';

export class Range extends Component {
    static displayName = Range.value;

    constructor(props) {
        super(props);
        this.state = { ranges: [], loading: true };
    }
    componentDidMount() {
        this.rangesData();
    }
    
    render() {
        return (
            <div>
                <h1>Maritime Test</h1>

                <p>Test</p>
            </div>
        );
    }
    async rangesData() {
        const response = await fetch('ranges');
        const data = await response.json();
        this.setState({ forecasts: ranges, loading: false });
    }
}
