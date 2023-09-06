#include "Matrix.h"

Matrix::Matrix(int n) {
    matrixOrder_ = n;
    row_ = new double[matrixOrder_];
    row_[0] = rand() + static_cast<double>(rand()) / RAND_MAX + 1;
    for (auto i = 1; i < matrixOrder_; i++) {
        row_[i] = static_cast<double>(rand()) / RAND_MAX * 10 + 1;
    }
}

Matrix::Matrix() {
    printf("Enter matrix order: ");
    matrixOrder_ = 0;
    std::cin >> matrixOrder_;
    row_ = new double[matrixOrder_];
    for (int i = 0; i < matrixOrder_; i++) {
        std::cout << i << " element: ";
        std::cin >> row_[i];
    }
}

Matrix::Matrix(int size, double* source) {
    matrixOrder_ = size;
    row_ = new double[matrixOrder_];
    for (int i = 0; i < matrixOrder_; i++) {
        row_[i] = source[i];
    }
}

Matrix::Matrix(const Matrix& source) {
    matrixOrder_ = source.matrixOrder_;
    row_ = new double[matrixOrder_];
    for (int i = 0; i < matrixOrder_; i++) {
        row_[i] = source.row_[i];
    }
}

Matrix::~Matrix() {
    delete[] row_;
}

Matrix& Matrix::operator=(const Matrix& source) {
    if (row_ != source.row_) {
        delete[] row_;
        matrixOrder_ = source.matrixOrder_;
        row_ = new double[matrixOrder_];
        for (int i = 0; i < matrixOrder_; i++) {
            row_[i] = source.row_[i];
        }
    }
    return *this;
}

/*
 b - left part
 x - array of answers
 */
void Matrix::Solve(double* b, double* x) {
    double* a = row_;
    int m = matrixOrder_;


    double* a1 = new double[m]; // auxiliary array
    double* b1 = new double[m]; // auxiliary array

    /* Local variables */
    int j, k, kj;
    double rk, sk, fkk;

    /* Function Body */
    a1[0] = 1. / a[0];
    x[0] = b[0] * a1[0];
    b1[0] = 0.;
    for (k = 2; k <= m; ++k) {
        a1[k - 1] = 0.;
        x[k - 1] = 0.;
        rk = 0.;
        fkk = 0.;
        for (j = 2; j <= k; ++j) {
            kj = k - j + 1;
            b1[j - 1] = a1[kj - 1];
            rk += a[j - 1] * b1[j - 1];
            fkk += a[j - 1] * x[kj - 1];
        }
        fkk = b[k - 1] - fkk;
        sk = 1. / (1. - rk * rk);
        rk = -rk * sk;
        for (j = 1; j <= k; ++j) {
            kj = k - j + 1;
            a1[j - 1] = a1[j - 1] * sk + b1[j - 1] * rk;
            x[kj - 1] += a1[j - 1] * fkk;
        }
    }

    delete[] a1;
    delete[] b1;
}