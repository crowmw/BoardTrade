import React from 'react'
import { createGlobalStyle, ThemeProvider } from 'styled-components'
import theme from './utils/theme'
import Header from './components/Header'

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
      <>
        <GlobalStyle />
        <Header />
        {children}
      </>
    </ThemeProvider>
  )
}

export default Layout
