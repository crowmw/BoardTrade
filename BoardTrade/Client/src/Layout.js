import React from 'react'
import { createGlobalStyle, ThemeProvider } from 'styled-components'
import theme from './utils/theme'
import Header from './components/Header'
import { BrowserRouter as Router } from 'react-router-dom'

const GlobalStyle = createGlobalStyle`
  body {
    padding: 0;
    margin: 0;
    font-family: -apple-system,Segoe UI,Roboto,Helvetica,Arial;
    background: ${({ theme }) => theme.colors.greyLightest}
  }

  *, *::before, *::after{
    box-sizing: border-box;
  }

  *:focus {
    outline: none;
  }
`

const Layout = ({ children }) => {
  return (
    <ThemeProvider theme={theme}>
      <Router>
        <>
          <GlobalStyle />
          <Header />
          {children}
        </>
      </Router>
    </ThemeProvider>
  )
}

export default Layout
