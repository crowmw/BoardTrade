import React, { Component } from 'react'
import { Route } from 'react-router-dom'
import { bindActionCreators } from 'redux'
import { connect } from 'react-redux'
// import logo from './logo.svg'
import Layout from '../Layout'
import AuthorizationPage from './AuthorizationPage'
import { fetchBoardGames } from '../actions/boardGameActions'
import { getBoardGamesKeys } from '../selectors/boardGameSelector'
import BoardGameListItem from '../containers/BoardGameListItem'

class Index extends Component {
  componentDidMount() {
    this.props.fetchBoardGames()
  }

  render() {
    const { boardGames } = this.props
    return (
      <Layout>
        <ul style={{ margin: 0, padding: 0, listStyle: 'none' }}>
          {boardGames.map(game => (
            <BoardGameListItem key={game} id={game} />
          ))}
        </ul>
        <Route path="/login" component={AuthorizationPage} />
      </Layout>
    )
  }
}

const mapStateToProps = state => ({
  boardGames: getBoardGamesKeys(state)
})

const mapDispatchToProps = dispatch =>
  bindActionCreators(
    {
      fetchBoardGames
    },
    dispatch
  )

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(Index)
