# lotto

A .NET Standard library for polling the current lottery numbers.

![](console.JPG)

## Introduction

My wife and I play the lottery from time to time. But I always forget where to look for the results when the big day of the draw finally arrives. So I end up visiting random lottery websites and get burried with ads, cookie-, and newsletter-popups. That's why I decided to create my own little lottery library that is able to poll the current draws - because I will never forget how to open the bash ;-)

## Getting Started

* Download the [latest **lotto** release](https://github.com/selmaohneh/lotto/releases) or clone the repository and build the project yourself!
* If you want to poll the lottery numbers for your own project, add a reference to the *lotto.core.dll*. Retrieve the current draws of all supported lotteries via ``IEnumerable<Draw> draws = Lotto.GetDraws();``.
