import React from 'react'
import { createGlobalStyle, ThemeProvider } from 'styled-components'
import theme from './utils/theme'
import Header from './components/Header'

const GlobalStyle = createGlobalStyle`
  body {
    padding: 0;
    margin: 0;
    font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", "Roboto", "Oxygen",
    "Ubuntu", "Cantarell", "Fira Sans", "Droid Sans", "Helvetica Neue",
    sans-serif;
    font-size: 14px;
    background: ${({ theme }) => theme.colors.greyLightest};
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
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
      <>
        <GlobalStyle />
        <Header />
        {children}
      </>
    </ThemeProvider>
  )
}

export default Layout
