import React, { Component } from 'react'
import { Route } from 'react-router-dom'
// import logo from './logo.svg'
import Layout from '../Layout'
import AuthorizationPage from './AuthorizationPage'

class Index extends Component {
  render() {
    return (
      <Layout>
        <Route path="/login" component={AuthorizationPage} />
      </Layout>
    )
  }
}

export default Index
