import React, { Component } from 'react'
import { Route } from 'react-router-dom'
// import logo from './logo.svg'
import Layout from '../Layout'
import Authorization from './Authorization'

class Index extends Component {
  render() {
    return (
      <Layout>
        <Route path="/login" component={Authorization} />
      </Layout>
    )
  }
}

export default Index
